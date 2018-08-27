using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommandLine;
using System.IO;
using LogicDemo.Nexus;
using LogicDemo.Logic;
using System.Linq;
using LogicDemo.Yammer;

namespace LogicDemo
{
    class Program
    {
        public enum ProgramAction
        {
            Ping,
            Sms
        }

        [Verb("ping", HelpText = "Ping the service gateway")]
        public class PingOptions
        {
        }


        [Verb("sms", HelpText = "Send an SMS")]
        public class SmsOptions
        {
            [Option('p', "phone", Required = true, HelpText = "The phone number to send the SMS to")]
            public string PhoneNumber { get; set; }

            [Option('b', "body", Required = true, HelpText = "The body of the SMS")]
            public string Body { get; set; }
        }


        [Verb("citizen", HelpText = "Get details of citizens")]
        public class CitizenOptions
        {
            [Option('c', "citizen", Required = false, HelpText = "The identifier of the citizen")]
            public int? CitizenId { get; set; }
        }

        [Verb("patients", HelpText = "Get details of patients")]
        public class PatientsOptions
        {
            [Option('c', "citizen", Required = true, HelpText = "The identifier of the citizen")]
            public int CitizenId { get; set; }            
        }

        [Verb("patient", HelpText = "Get details of a specific patient")]
        public class PatientOptions
        {
            [Option('p', "patient", Required = true, HelpText = "The identifier of the patient")]
            public int PatientId { get; set; }
        }

        [Verb("yammer", HelpText = "Get details of a yammer message")]
        public class YammerOptions
        {
            [Option('m', "message", Required = true, HelpText = "The identifier of the message")]
            public int MessageId { get; set; }

            [Option('p', "phone", Required = false, HelpText = "The phone number to send the SMS to")]
            public string PhoneNumber { get; set; }
        }

        static async Task<int> Main(string[] args)
        {
            try
            {
                var helpWriter = new StringWriter();
                var commandLineParser = new Parser(s =>
                {
                    s.HelpWriter = helpWriter;
                    s.CaseSensitive = false;
                    s.CaseInsensitiveEnumValues = true;
                });

                return await commandLineParser.ParseArguments<PingOptions, SmsOptions, CitizenOptions, PatientsOptions, PatientOptions, YammerOptions>(args)
                    .MapResult(
                        (PingOptions opts) => Ping(opts),
                        (SmsOptions opts) => Sms(opts),
                        (CitizenOptions opts) => Citizen(opts),
                        (PatientsOptions opts) => Patients(opts),
                        (PatientOptions opts) => Patient(opts),
                        (YammerOptions opts) => Yammer(opts),
                        errs =>
                        {
                            Console.WriteLine(helpWriter.ToString());
                            return Task.FromResult(2);
                        }
                    ).ConfigureAwait(false);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 255;
            }
        }

        private static async Task<int> Ping(PingOptions opts)
        {
            var api = new LogicApi();

            var version = await api.PingAsync().ConfigureAwait(false);

            Console.WriteLine($"Ping recieved, API Version = {version}");

            return 0;
        }

        private static async Task<int> Sms(SmsOptions opts)
        {
            if (!ValidateSmsArguments(opts)) return 255;

            var api = new LogicApi();

            var smsId = await api.SendSmsAsync(opts.PhoneNumber, opts.Body).ConfigureAwait(false);

            Console.WriteLine($"Message sent, SmsMessageId = {smsId}");

            return 0;
        }

        static bool ValidateSmsArguments(SmsOptions opts)
        {
            if (!IsPhoneValid(opts.PhoneNumber))
            {
                Console.WriteLine("Invalid phone number");
            }

            if (string.IsNullOrWhiteSpace(opts.Body))
            {
                Console.WriteLine("Body is required");
            }
            if (opts.Body.Length > 160)
            {
                Console.WriteLine("Body cannot be longer than 160 characters");
            }

            return true;
        }

        private static bool IsPhoneValid(string phoneNumber)
        {
            return true; //Match(phoneNumber, @"^(\+\d{1,3}[- ]?)?\d{10}$");
        }

        private static async Task<int> Citizen(CitizenOptions opts)
        {
            var api = new NexusApi();

            if (opts.CitizenId == null)
            {
                var list = await api.GetCitizensAsync().ConfigureAwait(false);

                Console.WriteLine($"{list.Count:N0} citizens fetched");
                foreach (var citizen in list)
                {
                    Console.WriteLine($"{citizen.Id,6:D} {citizen.Name}");
                }
            }
            else
            {
                var details = await api.GetCitizenAsync(opts.CitizenId.Value).ConfigureAwait(false);

                if (details == null)
                {
                    Console.WriteLine($"Citizen {opts.CitizenId.Value} does not exist");
                    return 0;
                }

                Console.WriteLine($"Citizen {details.Id} fetched");

                var serialiser = new YamlDotNet.Serialization.Serializer();
                var yml = serialiser.Serialize(details);
                Console.WriteLine(yml);
            }

            return 0;
        }

        private static async Task<int> Patients(PatientsOptions opts)
        {
            var api = new NexusApi();

            var filter = await api.FilterPatientsAsync(opts.CitizenId).ConfigureAwait(false);

            if (filter.TotalItems == 0)
            {
                Console.WriteLine("Citizen has no patients");
                return 1;
            }

            foreach (var page in filter.Pages)
            {
                var data = page.Links.FirstOrDefault(x => x.Key == "patientData");
                if (data.Value == null)
                {
                    Console.WriteLine("Unable to fetch a page of patients");
                    return 255;
                }

                var match = Regex.Match(data.Value?.Href ?? string.Empty, @"\?ids=(\d+(,\d+)*)");
                if (!match.Success)
                {
                    Console.WriteLine("Unable to determine patient ids");
                    return 255;
                }

                var idList = match.Groups[1].ToString();

                var patients = await api.GetPatients(idList).ConfigureAwait(false);

                foreach (var patient in patients)
                {
                    Console.WriteLine($"{patient.Id,6:D} {patient.FullReversedName}");
                }
            }

            return 0;
        }

        private static async Task<int> Patient(PatientOptions opts)
        {
            var api = new NexusApi();

            var patient = (await api.GetPatients(opts.PatientId.ToString()).ConfigureAwait(false)).FirstOrDefault();

            if (patient == null)
            {
                Console.WriteLine($"Patient {opts.PatientId} does not exist");
                return 0;
            }

            var serialiser = new YamlDotNet.Serialization.Serializer();
            var yml = serialiser.Serialize(patient);
            Console.WriteLine(yml);

            return 0;
        }

        private static async Task<int> Yammer(YammerOptions opts)
        {
            var api = new YammerApi();

            var message = await api.GetMessageAsync(opts.MessageId).ConfigureAwait(false);

            if (message == null)
            {
                Console.WriteLine($"Message {opts.MessageId} does not exist");
                return 0;
            }

            var sep = new string('-', 80);

            Console.WriteLine($"{sep}\n{message.Body.Plain}\n{sep}\n\n{message.LikedBy.Count:N0} Likes, including:");

            foreach (var name in message.LikedBy.Names)
            {
                Console.WriteLine($"- {name.FullName}");
            }

            if (!string.IsNullOrEmpty(opts.PhoneNumber))
            {
                if (!IsPhoneValid(opts.PhoneNumber))
                {
                    Console.WriteLine("Invalid phone number");
                }

                Console.WriteLine("\nMonitoring, press Ctrl+C to exit ...");

                var lastCount = message.LikedBy.Count;
                var dots = 0;

                for (; ;)
                {
                    await Task.Delay(3000).ConfigureAwait(false);

                    message = await api.GetMessageAsync(opts.MessageId).ConfigureAwait(false);

                    if (message == null)
                    {
                        Console.WriteLine($"Message {opts.MessageId} does not exist");
                        return 0;
                    }

                    if (message.LikedBy.Count != lastCount)
                    {
                        var body = $"Like count changed from {lastCount:N0} to {message.LikedBy.Count:N0}";

                        if (dots > 0) Console.WriteLine();

                        Console.WriteLine(body);

                        var result = await Sms(new SmsOptions { PhoneNumber = opts.PhoneNumber, Body = body }).ConfigureAwait(false);
                        if (result != 0) return result;

                        lastCount = message.LikedBy.Count;
                        dots = 0;
                    }
                    else
                    {
                        if (dots > 80)
                        {
                            Console.Write("\n.");
                            dots = 1;
                        }
                        else
                        {
                            Console.Write(".");
                            dots++;
                        }
                    }
                }
            }

            return 0;
        }
    }
}

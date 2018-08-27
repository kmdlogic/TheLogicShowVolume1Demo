using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LogicDemo.Yammer
{
    public class YammerMessage
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("sender_id")]
        public long SenderId { get; set; }

        [JsonProperty("replied_to_id")]
        public long? RepliedToId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("network_id")]
        public long NetworkId { get; set; }

        [JsonProperty("message_type")]
        public string MessageType { get; set; }

        [JsonProperty("sender_type")]
        public string SenderType { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("web_url")]
        public string WebUrl { get; set; }

        [JsonProperty("body")]
        public YammerBody Body { get; set; }

        [JsonProperty("thread_id")]
        public long ThreadId { get; set; }

        [JsonProperty("client_type")]
        public string ClientType { get; set; }

        [JsonProperty("client_url")]
        public string ClientUrl { get; set; }

        [JsonProperty("system_message")]
        public bool SystemMessage { get; set; }

        [JsonProperty("direct_message")]
        public bool DirectMessage { get; set; }

        [JsonProperty("chat_client_sequence")]
        public object ChatClientSequence { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("notified_user_ids")]
        public List<long> NotifiedUserIds { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("attachments")]
        public List<YammerAttachment> Attachments { get; set; }

        [JsonProperty("liked_by")]
        public YammerLikedBy LikedBy { get; set; }

        [JsonProperty("content_excerpt")]
        public string ContentExcerpt { get; set; }
    }
}

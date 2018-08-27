using Newtonsoft.Json;
using System;

namespace LogicDemo.Yammer
{
    public class YammerAttachment
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("network_id")]
        public long NetworkId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("web_url")]
        public string WebUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("content_class")]
        public string ContentClass { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("official")]
        public bool Official { get; set; }

        [JsonProperty("storage_type")]
        public string StorageType { get; set; }

        [JsonProperty("target_type")]
        public string TargetType { get; set; }

        [JsonProperty("small_icon_url")]
        public string SmallIconUrl { get; set; }

        [JsonProperty("large_icon_url")]
        public string LargeIconUrl { get; set; }

        [JsonProperty("download_url")]
        public string DownloadUrl { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("large_preview_url")]
        public string LargePreviewUrl { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("owner_type")]
        public string OwnerType { get; set; }

        [JsonProperty("last_uploaded_at")]
        public string LastUploadedAt { get; set; }

        [JsonProperty("last_uploaded_by_id")]
        public long LastUploadedById { get; set; }

        [JsonProperty("last_uploaded_by_type")]
        public string LastUploadedByType { get; set; }

        [JsonProperty("uuid")]
        public Guid? Uuid { get; set; }

        [JsonProperty("transcoded")]
        public bool? Transcoded { get; set; }

        [JsonProperty("streaming_url")]
        public string StreamingUrl { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("y_id")]
        public long YId { get; set; }

        [JsonProperty("overlay_url")]
        public string OverlayUrl { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("group_id")]
        public long? GroupId { get; set; }

        [JsonProperty("file")]
        public YammerFile File { get; set; }

        [JsonProperty("latest_version_id")]
        public long LatestVersionId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("real_type")]
        public string RealType { get; set; }

        [JsonProperty("msg", NullValueHandling = NullValueHandling.Ignore)]
        public string Msg { get; set; }
    }
}

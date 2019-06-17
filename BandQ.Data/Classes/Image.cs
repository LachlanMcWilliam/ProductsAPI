namespace BandQ.Data.Classes
{
    public class Image
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public byte[] Data { get; set; }
        public string MimeType { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }

        public virtual Product Product { get; set; }
    }
}
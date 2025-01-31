using System.ComponentModel.DataAnnotations.Schema;

namespace ConvertBlob.Models
{
    public class FileData
    {
        public int Id { get; set; }
        public byte[]? Bytes { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string? Name { get; set; }
    }
}

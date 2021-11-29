using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuickMaster.Models
{
    public class Book : IValidatableObject
    {
        public int Id { get; set; }
        [DisplayName("書名")]
        [Required(ErrorMessage = "{0}は必須です。")]
        public string Title { get; set; }
        [DisplayName("価格")]
        [Range(0, 5000, ErrorMessage = "{0}は{1}～{2}円以内で入力してください。")]
        [DataType(DataType.Currency)]
        public int Price { get; set; }
        [DisplayName("出版社")]
        [StringLength(20, ErrorMessage = "{0}は{1}文字以内で入力してください。")]
        public string Publisher { get; set; }
        [DisplayName("配布サンプル")]
        public bool Sample { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Publisher == "フリー文庫" && this.Price > 0)
            {
                yield return new ValidationResult(
                    "フリー文庫の価格は0円でなければいけません。",
                    new[] { "Price" });
            }
        }
    }
}

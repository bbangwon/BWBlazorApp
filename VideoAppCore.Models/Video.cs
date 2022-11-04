using System.ComponentModel.DataAnnotations;
using VideoAppCore.Models.Common;

namespace VideoAppCore.Models
{
    public class Video : AuditableBase
    {
        /// <summary>
        /// 일련번호
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 제목
        /// </summary>
        [Required]
        public string? Title { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// 작성자
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 회사
        /// </summary>
        public string? Company { get; set; }
    }
}

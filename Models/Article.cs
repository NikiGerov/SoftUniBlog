using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Article
    {
        private ICollection<Tag> tags;

        public Article()
        {
            this.tags = new HashSet<Tag>();
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------
        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------

        public Article(string authorId, string title, string context, int categoryId)
        {
            this.AuthorId = authorId;
            this.Title = title;
            this.Content = context;
            this.CategoryId = categoryId;
            this.tags = new HashSet<Tag>();

        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Content { get; set; }

        //public DateTime DateAdded { get; set; }
        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public bool IsAuthor(string name)
        {
            return this.Author.UserName.Equals(name);
        }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }


    }

    
}
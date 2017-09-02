using Events.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Events.Web.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDateTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Author { get; set; }
        public string Location { get; set; }


        public static Expression<Func<Event, EventViewModel>> ViewModel
        {
            get
            {
                return e => new EventViewModel()
                {
                    Id = e.Id,
                    Title = e.Title,
                    StartDateTime = e.StartDateTime,
                    Duration = e.Duration,
                    Location = e.Location,
                    Author = e.Author.FullName
                };
            }
        }
    }

    public class EventDetailsViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public static Expression<Func<Event, EventDetailsViewModel>> ViewModel
        {
            get
            {
                return e => new EventDetailsViewModel()
                {
                    Id = e.Id,
                    Description = e.Description,
                    Comments = e.Comments.AsQueryable().Select(CommentViewModel.ViewModel),
                    AuthorId = e.Author.Id
                };
            }
        }
    }

    public class CommentViewModel
    {
        public string Text { get; set; }
        public string Author { get; set; }
        public static Expression<Func<Comment, CommentViewModel>> ViewModel
        {
            get
            {
                return c => new CommentViewModel()
                {
                    Text = c.Text,
                    Author = c.Author.FullName
                };
            }
        }
    }
}
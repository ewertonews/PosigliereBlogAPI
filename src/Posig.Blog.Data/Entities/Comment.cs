﻿namespace Posig.Blog.Data.Entities
{
    public class Comment : BaseEntity
    {
        public required string CommentedByName { get; set; }
        public required string CommentText { get; set; }
    }
}

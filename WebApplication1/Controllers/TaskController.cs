using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private static List<Comment> comments = new List<Comment>
    {
        new Comment { Id = 1, TaskId = 1, Content = "Comment 1" }
    };

    [HttpGet("{taskId}")]
    public ActionResult<IEnumerable<Comment>> GetComments(int taskId) => Ok(comments.Where(c => c.TaskId == taskId));

    [HttpPost]
    public ActionResult CreateComment([FromBody] Comment comment)
    {
        comment.Id = comments.Max(c => c.Id) + 1;
        comments.Add(comment);
        return CreatedAtAction(nameof(GetComments), new { taskId = comment.TaskId }, comment);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateComment(int id, [FromBody] Comment updatedComment)
    {
        var comment = comments.FirstOrDefault(c => c.Id == id);
        if (comment == null)
            return NotFound();

        comment.Content = updatedComment.Content;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteComment(int id)
    {
        var comment = comments.FirstOrDefault(c => c.Id == id);
        if (comment == null)
            return NotFound();

        comments.Remove(comment);
        return NoContent();
    }
}
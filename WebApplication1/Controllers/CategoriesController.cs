using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        private static List<Category> categories = new List<Category>
    {
        new Category { Id = 1, Name = "General" },
        new Category { Id = 2, Name = "Urgent" }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() => Ok(categories);

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public ActionResult CreateCategory([FromBody] Category category)
        {
            category.Id = categories.Max(c => c.Id) + 1;
            categories.Add(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, [FromBody] Category updatedCategory)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            category.Name = updatedCategory.Name;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            categories.Remove(category);
            return NoContent();
        }
    }
}

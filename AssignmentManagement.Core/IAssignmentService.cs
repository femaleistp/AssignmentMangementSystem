using System.Collections.Generic;

namespace AssignmentManagement.Core
{
    public interface IAssignmentService
    {
        bool AddAssignment(Assignment assignment);
        List<Assignment> ListAll();
        List<Assignment> ListIncomplete();
        Assignment FindAssignmentByTitle(string title);
        bool MarkAssignmentComplete(string title);
        bool DeleteAssignment(string title);
        bool UpdateAssignment(string oldTitle, string newTitle, string newDescription);
    }
}

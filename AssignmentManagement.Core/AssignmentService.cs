using System;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentManagement.Core
{
    public class AssignmentService : IAssignmentService // Class to manage assignments
    {
        private readonly List<Assignment> _assignments = new(); 
        // List to store assignments

        public bool AddAssignment(Assignment assignment) // Constructor 
        {
            if (_assignments.Any(a => a.Title.Equals(assignment.Title, StringComparison.OrdinalIgnoreCase)))
            {
                return false; // Duplicate title exists
            }

            _assignments.Add(assignment); // Add assignment to the list
            return true; // Assignment added successfully
        }

        public List<Assignment> ListAll()
        {
            return new List<Assignment>(_assignments); // Return a copy of the list
        }

        public List<Assignment> ListIncomplete()
        {
            return _assignments.Where(a => !a.IsCompleted).ToList(); 
            // Filter incomplete assignments
        }

        // TODO: Implement method to find an assignment by title
        public Assignment FindAssignmentByTitle(string title)
        {
            return _assignments
                .FirstOrDefault(a => a.Title.Equals(title, StringComparison.OrdinalIgnoreCase)); 
            // Case-insensitive search
        }

        // TODO: Implement method to mark an assignment complete
        public bool MarkAssignmentComplete(string title)
        {
            var assignment = FindAssignmentByTitle(title); 
            // Find assignment by title
            if (assignment == null)
                return false; // Assignment not found

            assignment.MarkComplete();
            return true; // Assignment marked as complete
        }

        // TODO: Implement method to delete an assignment by title
        public bool DeleteAssignment(string title)
        {
            var assignment = FindAssignmentByTitle(title); 
            // Find assignment by title
            if (assignment == null)
                return false; // Assignment not found

            _assignments.Remove(assignment); // Remove assignment from the list
            return true; // Assignment deleted successfully
        }

        // TODO: Implement method to update an assignment (title and description)
        public bool UpdateAssignment(string oldTitle, string newTitle, string newDescription)
        {
            var assignment = FindAssignmentByTitle(oldTitle); 
            // Find assignment by old title
            if (assignment == null)
                return false; // Assignment not found

            if (!oldTitle.Equals(newTitle, StringComparison.OrdinalIgnoreCase) &&
                _assignments.Any(a => a.Title.Equals(newTitle, StringComparison.OrdinalIgnoreCase))) 
                // Check for duplicate title
            {
                return false; // Duplicate title exists
            }

            assignment.Update(newTitle, newDescription); // Update assignment details
            return true; // Assignment updated successfully 
        }
    }
}

using System;

namespace AssignmentManagement.Core
{
    public class Assignment
    {
        public string Title { get; private set; } 
        // Property to store assignment title

        public string Description { get; private set; } 
        // Property to store assignment details

        public bool IsCompleted { get; private set; } 
        // Property to track completion status

        public Assignment(string title, string description)
        {
            Validate(title, nameof(title)); 
            // Validate inputs

            Validate(description, nameof(description)); 
            // Validate inputs

            Title = title; 
            // Set the title
            
            Description = description; 
            // Set the assignment details
            
            IsCompleted = false; 
            // Default to not completed
        }

        public void Update(string newTitle, string newDescription)
        {
            Validate(newTitle, nameof(newTitle)); 
            // Validate new title

            Validate(newDescription, nameof(newDescription)); 
            // Validate new description

            Title = newTitle; 
            // Update the title

            Description = newDescription; 
            // Update the assignment details
        }

        public void MarkComplete()
        {
            IsCompleted = true; // Mark the assignment as completed
        }

        private void Validate(string input, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input))
            
                throw new ArgumentException($"{fieldName} cannot be blank or whitespace.");
            
            
        }
    }
}

﻿namespace ContactManagerApplication.DTOs
{
    public class ContactGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}

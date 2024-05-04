using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating job instances
        Job job1 = new Job
        {
            _company = "Microsoft",
            _jobTitle = "Software Engineer",
            _startYear = 2019,
            _endYear = 2022
        };

        Job job2 = new Job
        {
            _company = "Apple",
            _jobTitle = "Manager",
            _startYear = 2022,
            _endYear = 2023
        };

        // Creating a resume instance
        Resume myResume = new Resume
        {
            _name = "Allison Rose"
        };
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Displaying the resume
        myResume.Display();
    }
}

namespace AbpReadConfiguration.Models
{
    public class JobSetting
    {
        public Job[] Jobs { get; set; }
        public Job[] GoodJobs { get; set; }
    }

    public class Job
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
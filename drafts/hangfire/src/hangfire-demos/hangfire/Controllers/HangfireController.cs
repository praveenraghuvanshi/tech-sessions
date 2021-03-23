using Microsoft.AspNetCore.Mvc;
using System;
using Hangfire;
using System.Threading;

namespace hangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        /// <summary>
        /// A fire and forget task
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public string Welcome()
        {
            var jobId = BackgroundJob.Enqueue(() => SendWelcomeEmail("Fire and Forget - Welcome "));
            
            return $"Welcome to hangfire !!! Thread Id: {System.Threading.Thread.CurrentThread.ManagedThreadId} and Job Id: {jobId}";
        }

        /// <summary>
        /// A Scheduled task
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        public string Discount()
        {
            var jobId = BackgroundJob.Schedule(() => SendWelcomeEmail("Delayed - Discount"), TimeSpan.FromSeconds(15));

            return $"Welcome to hangfire !!! Thread Id: {Thread.CurrentThread.ManagedThreadId} and Job Id: {jobId}";
        }

        /// <summary>
        /// A Recurring task
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        public string Report()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Recurring"), Cron.Minutely);

            return $"Welcome to hangfire !!! Thread Id: {Thread.CurrentThread.ManagedThreadId}";
        }

        public void SendWelcomeEmail(string message)
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, {message}");
        }
    }
}

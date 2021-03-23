# Hangfire - A background task scheduler in .Net



## Background Process - What?

A background process is a process that runs behind the scenes without user intervention

<img src=".\assets\bg-process.png" alt="Background Process" style="zoom:80%;" />



## Background Process - Example

- Fire and Forget

  - Sending a welcome email on user signup

- Delayed

  - Discount coupons after sometime a user has signed up

- Scheduled

  - Invoice generation

  - Batch imports from xml, csv, json

  - Cleanup such as Deleting users

  - Automated renewals

    

## Background Process - Why

- Offloading
- Better utilization of resources
- Responsive application



## Background Process - Challenges

-  Multiple ways to implement various scenarios (Threads, Timers, Tasks, daemons, windows services)
- Platform dependent implementations
- Clean API's
- Reliability
- Persistence
- Monitoring
- Distributed



## Hangfire

Hangfire is an **open-source** framework that helps you to create, process and manage your background jobs, i.e. operations you don't want to put in your request processing pipeline:

<img src=".\assets\hangfire-properties.png" alt="image-20210323122513476" style="zoom:80%;" />

**[Hangfire Overview](https://www.hangfire.io/overview.html)**



## Hangfire - Working

<img src=".\assets\hangfire-working.png" alt="image-20210323144143467" style="zoom:80%;" />



## Hangfire - Capabilities



<img src=".\assets\hangfire-operations.png" alt="image-20210323122259208" style="zoom:80%;" />



## Resources

- [Hangfire](https://www.hangfire.io/)
- [Asp.Net Core: Background Processing with Hangfire](https://www.youtube.com/playlist?list=PL2Q8rFbm-4rtH-5o6mzOFA0tombRfr4Be) - Ervis Trupja
- [Scheduling recurring jobs with Hangfire (In ASP.Net Core 3.1)](https://www.youtube.com/watch?v=sQyY0xvJ4-o)
- [Running Background Tasks in ASP.NET Core (HANGFIRE)](https://www.youtube.com/watch?v=UAWDMYKy8PM)
- [Background Tasks Without a Separate Service: Hangfire for ASP.NET – Webinar Recording](https://blog.jetbrains.com/dotnet/2020/02/14/background-tasks-without-separate-service-hangfire-asp-net-webinar-recording/)
- [Hangfire.Mongo](https://github.com/sergeyzwezdin/Hangfire.Mongo)
- [Hangfire.AzureDocumentDB](https://github.com/imranmomin/Hangfire.AzureDocumentDB)
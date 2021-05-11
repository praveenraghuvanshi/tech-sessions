# Microsoft Orleans



## Features

- Virtual Actor
- 

## Sample App

- eShopOnOrleans
  - 

## References

- [jplane/serverless-orleans: A demonstration of local development and debugging + serverless Azure deployment of a Dockerized Orleans application. (github.com)](https://github.com/jplane/serverless-orleans)
- Videos
  - [Building real applications with Orleans](https://channel9.msdn.com/Shows/On-NET/Building-real-applications-with-Orleans)
  - [On .NET Live - Deep Dive into Microsoft Orleans](https://youtu.be/R0ODfwU6MzQ)
    - Building distributed application should not be a rocket science
    - Scales from a simple application running on a single node to a complex one on multiple nodes
    - The above scale happens without changing lot of my code.
    - Virtual actors : grains 
    - grains have an identity
    - Orleans Cluster
    - Grains might be hosted on different machines, so Grain interface methods must be asynchronous
    - Change only configuration from local to azure
    - use bindings -> persistence storage, statelessworker
  - [Deploying Orleans Apps to Kubernetes](https://channel9.msdn.com/Shows/On-NET/Deploying-Orleans-Apps-to-Kubernetes)
    - ServiceId and ClusterId
    - Ports: silo to silo
  - [Developing in Microsoft Orleans - Dot Net North - August 2018](https://youtu.be/fMtOqFx4LL4?list=PL1dkp_qO-CX9X4PSoPgao9wNN8e2840kV)
  - Tutorials
    - [Getting Organised With Microsoft Orleans 2.0 in .NET Core - Gigi Labs (nullneuron.net)](https://gigi.nullneuron.net/gigilabs/getting-organised-with-microsoft-orleans-2-0-in-net-core/)
    - [VlaTo/chat-room: Simple chat room project to play with Microsoft Orleans and Xamarin.Forms (github.com)](https://github.com/VlaTo/chat-room)
    - [Deploying Orleans to Kubernetes (ulriksenblog.azurewebsites.net)](https://ulriksenblog.azurewebsites.net/deploying-orleans-to-kubernetes/)
  - fads
- sample
  - [HanBaoBao - Orleans sample application](https://github.com/ReubenBond/hanbaobao-web)
  - Chat app
  - Blog portal
  - 
- OrleansAkka

## Questions

- How is it different from Akka.Net and Service fabric?
- How is it different from Channels in .Net core 3.0 used for concurrency and TPL?
- Known issue/challenges in CloudworX
- Features of Orleans used in CloudworX
- Any Reference on internal of Orleans
- call through referral/something else
- how many rounds(Coding/DSA, System Design)?
- Project work?
- Hike %



## To READ

- https://gigi.nullneuron.net/gigilabs/getting-started-with-microsoft-orleans-2-0-in-net-core/
- https://gigi.nullneuron.net/gigilabs/getting-organised-with-microsoft-orleans-2-0-in-net-core/
- https://ulriksenblog.azurewebsites.net/orleans-grain-references/
- https://ulriksenblog.azurewebsites.net/state-versioning-in-orleans/
- https://ulriksenblog.azurewebsites.net/deploying-orleans-to-kubernetes/
- https://github.com/VlaTo/chat-room
- https://www.youtube.com/watch?v=fMtOqFx4LL4
- https://www.meetup.com/DotNetNorth/events/251417703/
- https://medium.com/@MaartenSikkema/using-dotnet-core-orleans-redux-and-websockets-to-build-a-scalable-realtime-back-end-cd0b65ec6b4d
- https://www.winwire.com/webinar/microsoft-orleans/?web_reg_id=success
- https://reposhub.com/dotnet/distributed-computing/OrleansContrib-Orleankka.html
- https://blog.marcinbudny.com/2016/05/comparing-orleans-to-service-fabric.html
- https://stackshare.io/orleans/alternatives
- https://softwareengineering.stackexchange.com/questions/398357/message-queue-with-multiple-consumers-locking-synchronous-on-a-field
- https://www.gamasutra.com/blogs/AshkanSaeediMazdeh/20151008/255588/Creating_scalable_backends_for_games_using_open_source_Orleans_framework.php
- https://gigi.nullneuron.net/gigilabs/a-dashboard-for-microsoft-orleans/
- [Orleans Meetup 11 Visualising Orleans](https://www.youtube.com/watch?v=WiAX_eGEuyo)
- https://slideplayer.com/slide/12688698/
- https://www.slideshare.net/WinWire/build-distributed-highly-scalable-applications-in-net-using-microsoft-orleans
- https://www.stellarsolutions.it/en/microsoft-orleans-presentation-part-1-theory/
- [Project Orleans - Actor Model framework](https://www.slideshare.net/nmackenzie/project-orleans)
- [Akka.net versus microsoft orleans](https://www.slideshare.net/BillTulloch/akkanet-versus-microsoft-orleans)
- [Orleans – a “cloud native” runtime built for #azure](https://www.slideshare.net/Brisebois/orleans-a-cloud-native-runtime-built-for-azure)
- [Distributed caching with Microsoft Orleans](https://mcguirev10.com/2019/09/18/distributed-caching-with-microsoft-orleans.html)
- [Getting Started with Microsoft Orleans](https://dev.to/kritner/getting-started-with-microsoft-orleans-1765)
- Slides
  - [Microsoft Project Orleans](https://slideplayer.com/slide/4656419/)
- dfasd
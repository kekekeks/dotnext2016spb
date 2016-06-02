FROM aspnetbase
ADD scripts c:\scripts
ADD classicweb c:\classicweb
RUN cd c:\classicweb && ClassicWeb.deploy.cmd /Y
CMD powershell c:\scripts\run.ps1
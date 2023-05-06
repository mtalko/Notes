# Notes

Add dev certificate 
dotnet dev-certs https --trust
or configure self-signed or real one

run application.
After registration and login new "Notes" menu tab appear

For avoiding SQL Injection and XSS attacks there could be HttpUtility.HtmlEncode or other escaping approaches, but it is not needed in current implementation,
because MVC and EF take it under control. It could be added in case of work through ajax calls.

There were planned 
- ajax refreshing (with appropriate delete and put methods to work through API)
- update functionality
- separate view, db, indentity modules
- "anti spam" middleware

but due to lack of time it was not imlemented
Thanks for attention.
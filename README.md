# GeneralIndexAPI

OK, so I know this is far from perfect. It isn't even finished!

This will (hopefully) help those who have a General Index account to start to make API calls to get data using .Net 6.0

The code was built to do a specific job for us, I am sharing it to try to help you get a start, I do not work for General Index and therefore have not got time to spend lots of time adding to / updating / perfecting code and this is very much shared on an as is basis with no warranty as to performance.

On performance it is slow!! The API calls are OK but converting the response CSV format into C# is slow as I used a Generic converter that uses System.Reflection to inspect the Type of the C# object property the value is being assigned to, and then converting the string returned in the CSV to that data Type - this is not a quick process when being performed for every value on every row of the CSV - however as stated I built this to do a job for us and it is sufficient at that job and we are not processing massive amounts of data at a time.

I have written the code as a Library with a very simple Console program to demonstrate how to use it.

You need an account with General Index (GI) for this to work at all but once you have this put your username and password into the code, or better yet utilise UserSecrets and pass them in as parameters to the LoginAsync method found in the GIAPI class in the Library (rows 31 and 32 in the GIAPI.cs file)

The GI documentation for the API can be found at https://docs.g-x.co and if you want any information regarding their service or you want to get an account you can email them at support@general-index.com to arrange getting an API key.

I will happily answer questions regarding the code in this repository when I have time, but only when I have time, this is not a labour of love and this does not pay my bills so responses may well be long in coming, sorry.

Lastly I would genuinely like to hear your feedback, as you are here you are probably a better coder than I am so please feel free to improve and add to this, to help others out.

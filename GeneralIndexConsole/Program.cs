using GeneralIndexAPILibrary.Models;
using GeneralIndexAPILibrary.Controller;


// The HttpMessageReporting determines whether the output is shown on the console while debugging. If this is not needed set the parameter to HttpMessageReporting.OFF

GIController client = new GIController(HttpMessageReporting.VERBOSE);

await client.StartNewRequest(GIRequestType.LOGIN);
await client.StartNewRequest(GIRequestType.RETRIEVE_SINGLE_INDEX_TIMESERIES);
var returnedValues = await client.SendRetrieveSingleIndexTimeSeriesMessage();

await client.StartNewRequest(GIRequestType.LOGOUT);










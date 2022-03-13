using NUnit.Framework;
using RestSharp;
using System.Net;

namespace weather.Integrations.Tests.StepDefinitions
{
    [Binding]
    public class UserRequestTheForecasStepDefinitions
    {
        string address = "";
        string contentResult = "";

        [Given(@"the user enter int index page")]
        public void GivenTheUserEnterIntIndexPage() {}

        [Given(@"write the address '([^']*)'")]
        public void GivenWriteTheAddress(string p0)
        {
            address = p0;
        }

        [When(@"the user submit the address")]
        public void WhenTheUserSubmitTheAddress()
        {
            var request = new HttpRequestWrapper()
                         .SetMethod(Method.Get)
                         .SetResourse("/api/get-forecast-from?address=4600 Silver Hill Rd, Washington, DC 20233")
                         .AddParameter("address", address);

            var restResponse = new RestResponse();
            restResponse = request.Execute();

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
            contentResult = restResponse.Content;
        }

        [Then(@"the forecast endpoint is called and return the result")]
        public void ThenTheForecastEndpointIsCalledAndReturnTheResult()
        {
            Assert.IsNotNull(contentResult);
        }
    }
}

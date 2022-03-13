using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace weather.api.tests.StepDefinitions
{
    [Binding]
    public class VerifyIfApplicationIsOnWorkStepDefinitions
    {
        HttpStatusCode statusCodeResult;

        [Given(@"the application is on working")]
        public void GivenTheApplicationIsOnWorking()
        {
        }

        [Given(@"the check endpoint is called")]
        public void GivenTheCheckEndpointIsCalled()
        {
            var request = new HttpRequestWrapper()
                .SetMethod(Method.Get)
                .SetResourse("/api/check");

            var restResponse = new RestResponse();
            restResponse = request.Execute();

            statusCodeResult = restResponse.StatusCode;
        }

        [Then(@"the response status should be Ok")]
        public void ThenTheResponseStatusShouldBeOk()
        {
            Assert.AreEqual(HttpStatusCode.OK, statusCodeResult);
        }
    }
}

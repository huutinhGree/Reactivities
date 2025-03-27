using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;
using MediatR;
using Application.Activities.Queries;
using Application.Activities.Commands;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities() {
        return await Mediator.Send(new GetActivityList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id) {
        return await Mediator.Send(new GetActivityDetails.Query{Id = id});
    }

    [HttpPost]

    public async Task<ActionResult<string>> CreateActivity(Activity activity) {
        return await Mediator.Send(new CreateActivity.Command{Activity = activity});
    }

    [HttpPut]
        public async Task<ActionResult> EditActivity(Activity activity)
    {
        await Mediator.Send(new EditActivity.Command{Activity = activity});
        return NoContent();

    }

    [HttpDelete("{id}")]

    public async Task<ActionResult> DeleteActivity(string id) 
    {
        await Mediator.Send(new DeleteActivity.Command{Id = id});

        return Ok();
    }
}



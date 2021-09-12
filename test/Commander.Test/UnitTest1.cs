using System;
using Xunit;
using Commander.Controllers;

using AutoMapper;
using Commander.Data;
using Commander.model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Commander.Test
{
    public class UnitTest1
    {
    
         
        [Fact]
        public void TestName()
        {
            
        CommanderController cc = new CommanderController();
        //Given

                var id = cc.getString("ahmed");
                Assert.Equal("ahmed",id.Value);
                
            
        //When
        
        //Then
        }
        [Fact]
        public void Test1()
        {

        }
    }
}

﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SchoolClient
{
    public class Program
    {
        private static IConfigurationRoot _configuration;
        private static ApiClient _apiClient;
        public static void Main(string[] args)
        {
            LoadConfig();
            _apiClient = new ApiClient(_configuration);

            ListStudents().Wait();
            ListCourses().Wait();

            Console.ReadLine();
            Console.ResetColor();
        }

        private static void LoadConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        private static async Task ListStudents()
        {
            var students = await _apiClient.GetStudents();
            Console.WriteLine($"Student Count: {students.Count()}");
        }

        private static async Task ListCourses()
        {
            var courses = await _apiClient.GetCourses();
            Console.WriteLine($"Courses Count: {courses.Count()}");
        }
    }
}

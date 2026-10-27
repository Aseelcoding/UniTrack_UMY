using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using UniTrack_UMY.Core.Models;
namespace UniTrack_UMY.Infrastructure.Services
{
    public class CourseParser
    {
        public List<Course> ParseCourses(string html)
        {
            var courses = new List<Course>();

            if (string.IsNullOrEmpty(html)) return courses;

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);


            var courseNodes = doc.DocumentNode.SelectNodes("//li[contains(@class, 'course-listitem')]");

            if (courseNodes == null) return courses;

            foreach (var node in courseNodes)
            {
                try
                {
                    var course = new Course();


                    course.Id = node.GetAttributeValue("data-course-id", string.Empty);
                    if (string.IsNullOrEmpty(course.Id)) continue;


                    var linkNode = node.SelectSingleNode(".//a[contains(@class, 'coursename')]");
                    if (linkNode != null)
                    {
                        // Clone the node to avoid modifying the original HTML document
                        var cleanNode = linkNode.CloneNode(true);

                        // Remove the hidden screen-reader spans and favorite icons
                        var unwantedNodes = cleanNode.SelectNodes(".//span[contains(@class, 'sr-only')] | .//span[@data-region='favourite-icon']");
                        if (unwantedNodes != null)
                        {
                            foreach (var unwanted in unwantedNodes)
                            {
                                unwanted.Remove();
                            }
                        }

                        course.Name = CleanText(cleanNode.InnerText);
                        course.Url = linkNode.GetAttributeValue("href", string.Empty);
                    }
                    else
                    {
                        continue; // If no name found, skip
                    }

                    var progressNode = node.SelectSingleNode(".//div[contains(@class, 'progress-text')]");
                    if (progressNode != null)
                    {
                        // "Course progress: 0% complete"

                        var match = Regex.Match(progressNode.InnerText, @"(\d+)%");
                        if (match.Success)
                        {
                            if (double.TryParse(match.Groups[1].Value, out double progress))
                            {
                                course.ProgressPercent = progress;
                                course.HasProgress = true;
                            }
                        }
                    }

                    courses.Add(course);
                }
                catch (Exception)
                {

                    continue;
                }
            }

            return courses;
        }

        private string CleanText(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            return Regex.Replace(text, @"\s+", " ").Trim();
        }
    }
}

using System;
using l2l.Data.Model;
using Xunit;
using l2l.Data.Repository;
using FluentAssertions;

namespace l2l.Data.Tests
{
    /// <summary>
    /// CRUD and list tests
    /// </summary>
    public class CourseRepositoryTests
    {
        [Fact]
        public void CourseRepositoryTests_CreateCourseShouldBeInRepository()
        {
            var sut = new CourseRepository();
            var course = new Course{Id = 1, Name="Test course"};

            sut.Add(course);
            var result = sut.GetById(course.Id);

            Assert.NotNull(result);
            //Assert.Equal(course, result); -> antipattern

            result.Should().BeEquivalentTo(course);

        }
    }
}

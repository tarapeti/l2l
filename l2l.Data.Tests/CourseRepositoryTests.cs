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

        /// <summary>
        /// Read test
        /// </summary>
        [Fact]
        public void CourseRepository_Read()
        {
            var sut = new CourseRepository();
            var course = new Course{Id = 1, Name="Test course"};
            sut.Add(course);
            
            var result = sut.GetById(course.Id);

            //Assert.NotNull(result);
            //Assert.Equal(course, result); -> antipattern

            result.Should().BeEquivalentTo(course);
            result.Should().BeEquivalentTo(course);

        }

        /// <summary>
        /// Update test
        /// </summary>
        [Fact]
        public void CourseRepository_Update()
        {
            var sut = new CourseRepository();
            var course = new Course{Id = 1, Name="Test course"};
            sut.Add(course);
            var toUpdate = sut.GetById(course.Id);

            toUpdate.Name = "Name changed";
            sut.Update(toUpdate);

            var afterUpdate = sut.GetById(course.Id);

            afterUpdate.Should().BeEquivalentTo(toUpdate);

        }


    }
}

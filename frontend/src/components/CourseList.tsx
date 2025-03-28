import React, { useEffect, useState } from 'react';
import { Course } from '../models/Course';
import api from '../services/api';
import { Button, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper } from '@mui/material';
import { Link } from 'react-router-dom';

const CourseList: React.FC = () => {
  const [courses, setCourses] = useState<Course[]>([]);

  useEffect(() => {
    const fetchCourses = async () => {
      try {
        console.log("Fetching courses..."); // Добавьте лог
        const response = await api.get('/courses');
        console.log("Received data:", response.data); // Лог данных
        setCourses(response.data);
      } catch (error) {
        console.error('Error fetching courses:', error);
      }
    };
  
    fetchCourses();
  }, []);

  return (
    <TableContainer component={Paper}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Title</TableCell>
            <TableCell>Description</TableCell>
            <TableCell>Price</TableCell>
            <TableCell>Duration</TableCell>
            <TableCell>
              <Button component={Link} to="/courses/new" variant="contained" color="primary">
                Add Course
              </Button>
            </TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {courses.map((course) => (
            <TableRow key={course.id}>
              <TableCell>{course.title}</TableCell>
              <TableCell>{course.description}</TableCell>
              <TableCell>${course.price}</TableCell>
              <TableCell>{course.durationInHours} hours</TableCell>
              <TableCell>
                <Button component={Link} to={`/courses/${course.id}`} variant="outlined">
                  Edit
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default CourseList;
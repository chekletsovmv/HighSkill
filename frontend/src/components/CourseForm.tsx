import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Course } from '../models/Course';
import api from '../services/api';
import { TextField, Button, Container, Box, Typography } from '@mui/material';
import { Link } from 'react-router-dom';

const CourseForm: React.FC = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [course, setCourse] = useState<Partial<Course>>({
    title: '',
    description: '',
    price: 0,
    durationInHours: 0,
    isActive: true
  });

  useEffect(() => {
    if (id) {
      const fetchCourse = async () => {
        try {
          const response = await api.get(`/courses/${id}`);
          setCourse(response.data);
        } catch (error) {
          console.error('Error fetching course:', error);
        }
      };
      fetchCourse();
    }
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      if (id) {
        await api.put(`/courses/${id}`, course);
      } else {
        await api.post('/courses', course);
      }
      navigate('/');
    } catch (error) {
      console.error('Error saving course:', error);
    }
  };

  return (
    <Container maxWidth="sm">
      <Box component="form" onSubmit={handleSubmit} sx={{ mt: 3 }}>
        <Typography variant="h6">{id ? 'Edit Course' : 'Add New Course'}</Typography>
        
        <TextField
          label="Title"
          value={course.title}
          onChange={(e) => setCourse({...course, title: e.target.value})}
          fullWidth
          margin="normal"
          required
        />
        
        <TextField
          label="Description"
          value={course.description}
          onChange={(e) => setCourse({...course, description: e.target.value})}
          fullWidth
          margin="normal"
          multiline
          rows={4}
        />
        
        <TextField
          label="Price"
          type="number"
          value={course.price}
          onChange={(e) => setCourse({...course, price: Number(e.target.value)})}
          fullWidth
          margin="normal"
          required
        />
        
        <TextField
          label="Duration (hours)"
          type="number"
          value={course.durationInHours}
          onChange={(e) => setCourse({...course, durationInHours: Number(e.target.value)})}
          fullWidth
          margin="normal"
          required
        />
        
        <Box sx={{ mt: 2 }}>
          <Button type="submit" variant="contained" color="primary">
            Save
          </Button>
          <Button component={Link} to="/" sx={{ ml: 2 }}>
            Cancel
          </Button>
        </Box>
      </Box>
    </Container>
  );
};

export default CourseForm;
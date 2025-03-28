import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import CourseList from './components/CourseList';
import CourseForm from './components/CourseForm';
import { Container, CssBaseline, Typography } from '@mui/material';

const App: React.FC = () => {
  return (
    <Router>
      <CssBaseline />
      <Container maxWidth="lg">
        <Typography variant="h4" component="h1" gutterBottom sx={{ mt: 3, mb: 3 }}>
          HighSkill Courses
        </Typography>
        
        <Routes>
          <Route path="/" element={<CourseList />} />
          <Route path="/courses/new" element={<CourseForm />} />
          <Route path="/courses/:id" element={<CourseForm />} />
        </Routes>
      </Container>
    </Router>
  );
};

export default App;
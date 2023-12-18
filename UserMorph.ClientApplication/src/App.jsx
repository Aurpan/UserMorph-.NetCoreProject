import './App.css'
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min";
import { Outlet } from 'react-router-dom';
import Header from './components/Header';
import { useState } from 'react';

function App() {

  return (
    <>
      <Header />
      <div className='container'>
        <div className='row'>
          <div className='col-md-12'>
            <Outlet />
          </div>
        </div>
      </div>
    </>
  )
}

export default App

import './App.css'
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min";
import UserList from './components/UserList';
import { Outlet } from 'react-router-dom';
import axios from './Axios';
import { useEffect } from 'react';

function App() {

  useEffect(() => {
    fetchUsers();
  }, []);

  const fetchUsers = () => {
    axios.get('/users').then(data => {
      console.log('data: ', data);
    });
  }

  return (
    <>
      <p>Heello APP com</p>
      <div className='container'>
        <div className='row'>
          <div className='col-md-12'>
            {/* <UserList /> */}
            <Outlet />
          </div>
        </div>
      </div>
    </>
  )
}

export default App

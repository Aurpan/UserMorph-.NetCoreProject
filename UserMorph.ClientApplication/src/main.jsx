import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import UserDetails from './components/UserDetails.jsx'
import UserList from './components/UserList.jsx'
import WrongRoute from './components/WrongRoute.jsx'

const router = createBrowserRouter([
	{
		path: '/',
		element: <App />,
		children: [
			{
				path: '',
				element: <UserList />
			},
			{
				path: '/users',
				element: <UserList />
			},
			{
				path: '/users/edit/:userId',
				element: <UserDetails />
			},
			{
				path: '*',
				element: <WrongRoute />
			}
		]
	}
]);

ReactDOM.createRoot(document.getElementById('root')).render(
	// <React.StrictMode>
	<RouterProvider router={router} />
	// </React.StrictMode>
)

import { Link, useLocation } from 'react-router-dom'
import { useEffect, useState } from 'react'
import axios from '../Axios';

export default function () {
    let [users, setUsers] = useState([]);
    let [dataProvider, setDataProvider] = useState(0);
    const { pathname } = useLocation();
    const editUrl = ['/users', '/users/'].includes(pathname) ? '' : 'users/';

    const changeDataSource = (event) => {
        const newSource = parseInt(event.target.value);
        setDataProvider(newSource);
    };

    useEffect(() => {
        fetchUsers(dataProvider);
    }, [dataProvider]);

    const fetchUsers = (dataProvider) => {
        console.log('dataSource: ', dataProvider);
        axios.get(`/users?dataSourceType=${dataProvider}`).then(response => {
            console.log('data: ', response.data);
            setUsers(response.data);
        });
    }

    return (
        <div className="user-list-container">
            <div className='ds-selector'>
                <select onChange={changeDataSource} value={dataProvider}>
                    <option value={0}>MS SQL Server</option>
                    <option value={1}>Json DB</option>
                </select>
            </div>
            <table className="table table-responsive table-bordered">
                <thead>
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Name</th>
                        <th scope="col">Company</th>
                        <th scope="col">Sex</th>
                        <th scope="col">Action</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        users.map(user =>
                            <tr key={user.id}>
                                <td scope="row">{user.id}</td>
                                <td>{`${user.firstName} ${user.lastName}`}</td>
                                <td>{user.company}</td>
                                <td>{user.sex}</td>
                                <td>
                                    <Link to={`${editUrl}edit/${user.id}?dataSourceType=${dataProvider}`}>Edit</Link>
                                </td>
                            </tr>
                        )
                    }
                </tbody>
            </table>
        </div>
    )
}
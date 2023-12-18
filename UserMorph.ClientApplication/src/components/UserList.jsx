import {Link} from 'react-router-dom'

const users = [
    {
        id: 1,
        name: 'imran vai',
        company: 'DSI',
        sex: 'Male'
    },
    {
        id: 2,
        name: 'imran jamai 1',
        company: 'DSI',
        sex: 'Female'
    },
    {
        id: 3,
        name: 'imran jami 2',
        company: 'DSI',
        sex: 'Male'
    }
];

export default function () {
    return (
        <div className="user-list-container">
            <table className="table">
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
                                <td>{user.name}</td>
                                <td>{user.company}</td>
                                <td>{user.sex}</td>
                                <td>
                                    <Link to={`users/edit/${user.id}`}>Edit</Link>
                                    {/* <button className="btn btn-outline-primary">Edit</button> */}
                                </td>
                            </tr>
                        )
                    }
                </tbody>
            </table>
        </div>
    )
}
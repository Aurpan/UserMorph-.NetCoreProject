import { Link } from 'react-router-dom'

export default function() {
    return (
        <div>
            <h2>Are you lost? Go to user list page by clicking the link below</h2>
            <Link to='/users'>User List</Link>
        </div>
    );
}
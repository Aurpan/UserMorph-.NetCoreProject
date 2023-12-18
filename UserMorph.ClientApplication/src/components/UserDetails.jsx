import { useEffect, useState } from "react";
import { useLocation, useParams } from "react-router-dom";
import axios from "../Axios";

export default function () {
    const [userData, setUserData] = useState(null);
    const { userId } = useParams();
    const { search } = useLocation();
    const dataSourceType = parseInt(search.split('=')[1]);

    useEffect(() => {
        // Simulating an API call
        const fetchData = async () => {
            try {
                const response = await axios.get(`/users/${userId}?dataSourceType=${dataSourceType}`);
                console.log('user: ', response.data);
                setUserData(response.data);

            } catch (error) {
                console.error('Error fetching user data:', error);
            }
        };

        fetchData();
    }, [userId, dataSourceType]);

    const handleInputChange = (field, value) => {
        setUserData((prevUserData) => ({
            ...prevUserData,
            [field]: value,
        }));
    };

    const handleContactInputChange = (contactIndex, field, value) => {
        setUserData((prevUserData) => ({
            ...prevUserData,
            contacts: prevUserData.contacts.map((contact, index) =>
                index === contactIndex ? { ...contact, [field]: value } : contact
            ),
        }));
    };

    const handleRoleInputChange = (roleIndex, field, value) => {
        setUserData((prevUserData) => ({
            ...prevUserData,
            roles: prevUserData.roles.map((role, index) =>
                index === roleIndex ? { ...role, [field]: value } : role
            ),
        }));
    };

    const updateData = () => {
        axios.put(`/users`, userData);
    }

    const deleteUser = () => {
        axios.delete(`/users/${userData.id}`).then(() => {
            console.log('delete success');
        })
            .catch(err => {
                console.log('failed to delete');
            })
    }

    if (!userData) {
        return <p>Loading...</p>;
    }

    return (
        <>
            <div className="row">
                <div className="col-md-6">
                    <h1>User Details</h1>

                    <div className="mb-2">
                        <label for="fname" class="form-label">First Name</label>
                        <input
                            id="fname"
                            className="form-control form-control-sm"
                            type="text"
                            value={userData.firstName}
                            onChange={(e) => handleInputChange('firstName', e.target.value)}
                        />
                    </div>

                    <div className="mb-2">
                        <label for="lname" class="form-label">Last Name</label>
                        <input
                            id="lname"
                            className="form-control form-control-sm"
                            type="text"
                            value={userData.lastName}
                            onChange={(e) => handleInputChange('lastName', e.target.value)}
                        />
                    </div>

                    <div className="mb-2">
                        <label for="company" class="form-label">Company</label>
                        <input
                            id="company"
                            type="text"
                            className="form-control form-control-sm"
                            value={userData.company}
                            onChange={(e) => handleInputChange('company', e.target.value)}
                        />
                    </div>

                    <div className="mb-2">
                        <label for="sex" class="form-label">Sex</label>
                        <select
                            id="sex"
                            value={userData.sex}
                            onChange={e => handleInputChange('sex', parseInt(e.target.value))}
                            className="form-select-sm"
                        >
                            <option value={0}>Male</option>
                            <option value={1}>Female</option>
                            <option value={2}>Others</option>
                        </select>
                    </div>

                    <div>
                        Active:
                        <input
                            className="form-check-input"
                            type="checkbox"
                            checked={userData.isActive}
                            onChange={(e) => handleInputChange('isActive', e.target.checked)}
                        />
                    </div>

                    <h2>Roles</h2>
                    {userData.roles.map((role, index) => (
                        <div key={role.roleId}>
                            <p>
                                Name:
                                <select
                                    value={role.roleId}
                                    onChange={(e) => handleRoleInputChange(index, 'roleId', parseInt(e.target.value))}
                                    className="form-select-sm"
                                >
                                    <option value={0}>Manager</option>
                                    <option value={1}>Admin</option>
                                    <option value={2}>Lead</option>
                                    <option value={3}>Staff</option>
                                </select>

                            </p>
                        </div>
                    ))}
                </div>
                <div className="col-md-6">
                    <h2>Contact Information</h2>
                    {userData.contacts.map((contact, index) => (
                        <>
                            {index == 0 ? (<h3>Present</h3>) : (<h3>Permanent</h3>)}
                            <div key={contact.id}>
                                <p>
                                    Phone:
                                    <input
                                        type="text"
                                        value={contact.phone}
                                        onChange={(e) => handleContactInputChange(index, 'phone', e.target.value)}
                                    />
                                </p>
                                <p>
                                    Address:
                                    <input
                                        type="text"
                                        value={contact.address}
                                        onChange={(e) => handleContactInputChange(index, 'address', e.target.value)}
                                    />
                                </p>
                                <p>
                                    City:
                                    <input
                                        type="text"
                                        value={contact.city}
                                        onChange={(e) => handleContactInputChange(index, 'city', e.target.value)}
                                    />
                                </p>
                                <p>
                                    Country:
                                    <input
                                        type="text"
                                        value={contact.country}
                                        onChange={(e) => handleContactInputChange(index, 'country', e.target.value)}
                                    />
                                </p>
                            </div>
                            {index == 0 && <hr />}
                        </>
                    ))}
                </div>
            </div>
            {dataSourceType != 0 && (
                <div className="row">
                    <div className="col-md-12">
                        <button onClick={updateData} className="btn btn-primary">Save</button>
                        <button onClick={deleteUser} className="btn btn-danger">Delete</button>
                    </div>
                </div>
            )}
        </>
    );

};


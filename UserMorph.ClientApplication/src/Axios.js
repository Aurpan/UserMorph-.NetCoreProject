import axios from "axios"

const axiosInstance = axios.create({
    baseURL: 'https://localhost:7072/api'
});

export default axiosInstance;
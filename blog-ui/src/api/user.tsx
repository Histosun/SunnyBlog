import request from '../utils/request'

interface LoginRequest{
    username: string,
    password: string
};

export const login = (loginRequest: LoginRequest)=>{
    return request({
        url: `/Login/LoginByUsernamePassword`,
        method: "post",
        headers: {
            isToken: false
        },
        data: {
            'username': loginRequest.username,
            'password': loginRequest.password
        }
    })
}
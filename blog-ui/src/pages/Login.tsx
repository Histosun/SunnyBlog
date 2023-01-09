import {
    GithubOutlined,
    LockOutlined,
    MailOutlined,
    GoogleOutlined,
    UserOutlined,
    FacebookOutlined,
} from '@ant-design/icons';
import {
    LoginForm,
    ProFormCheckbox,
    ProFormText,
    ProConfigProvider,
} from '@ant-design/pro-components';
import { Space } from 'antd';
import { CSSProperties, useContext } from 'react';
import { useState } from 'react';
import { Link, useNavigate } from "react-router-dom"
import { login } from '../api/user';
import AuthContext from '../context/AuthContext';

type LoginType = 'account' | 'email';

const iconStyles: CSSProperties = {
    marginInlineStart: '16px',
    color: 'rgba(0, 0, 0, 0.2)',
    fontSize: '24px',
    verticalAlign: 'middle',
    cursor: 'pointer',
};

const Login = () => {
    const [loginType, setLoginType] = useState<LoginType>('account');
    const navigate = useNavigate();

    const { dispatch } = useContext(AuthContext);

    const onSubmit = async (values:any) => { 
        login(values)
            .then(response => {
                // console.log(response.data)
                dispatch({ type: 'login', payload: response.data });
                navigate("/Home");
            })
    }

    return (
        <ProConfigProvider hashed={false}>
        <div style={{ backgroundColor: 'white' }}>
            <LoginForm
                logo="https://github.githubassets.com/images/modules/logos_page/Octocat.png"
                title="SunnyBlog"
                subTitle="Zhaoyang's Personal Blog Project"
                actions={
                    <Space>
                        Other login methods
                        <GithubOutlined style={iconStyles} />
                        <GoogleOutlined style={iconStyles} />
                        <FacebookOutlined style={iconStyles} />
                    </Space>
                }
                submitter={
                    {searchConfig: { submitText: "Login"}}
                }
                onFinish={onSubmit}
            >
            {(
            <>
                <ProFormText
                    name="username"
                    fieldProps={{
                    size: 'large',
                    prefix: <UserOutlined className={'prefixIcon'} />,
                    }}
                    placeholder={'username'}
                    rules={[
                        {
                            required: true,
                            message: 'Username cannot be empty!',
                        },
                    ]}
                />
                <ProFormText.Password
                    name="password"
                    fieldProps={{
                    size: 'large',
                    prefix: <LockOutlined className={'prefixIcon'} />,
                    }}
                    placeholder={'password'}
                    rules={[
                        {
                            required: true,
                            message: 'Password cannot be empty！',
                        },
                    ]}
                />
            </>
            )}
                <div
                    style={{
                    marginBlockEnd: 24,
                    }}>
                    <ProFormCheckbox noStyle name="autoLogin">
                        remember me
                    </ProFormCheckbox>
                    <Link to="/SignUp"
                        style={{
                            float: 'right',
                        }}
                    >
                        forget password
                    </Link>
                </div>
            </LoginForm>
        </div>
        </ProConfigProvider>
    );
};

export default Login;
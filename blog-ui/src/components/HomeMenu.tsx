import React, { useContext } from 'react';
import { Row, Col } from 'antd';
import { HomeOutlined, UnorderedListOutlined, UserOutlined } from '@ant-design/icons';
import type { MenuProps } from 'antd';
import { Menu, Avatar } from 'antd';
import { useNavigate } from 'react-router-dom';
import AuthContext from '../context/AuthContext';
import { SubMenuType } from 'antd/es/menu/hooks/useItems';

type MenuItem = Required<MenuProps>['items'][number];
type MenuClickEventHandler = Required<MenuProps>['onClick'];

interface LoginMenuItem {
    items: MenuItem[],
    onClick: MenuClickEventHandler
}

const HomeMenu: React.FC = () => {
    const navigate = useNavigate();

    const {user} = useContext(AuthContext);

    const leftItems: MenuItem[] = [
        { key: "home", icon: <HomeOutlined />, label: "Home" },
        { key: "category", icon: <UnorderedListOutlined />, label: "Category" },
    ];

    const leftMenuOnClick: MenuClickEventHandler = ({ key, keyPath, domEvent }) => {
        navigate("/home");
    }

    const unLoggedItem: LoginMenuItem = {
        items: [
            { key: "login", icon: <UserOutlined />, label: "Login" }
        ],
        onClick: ({ key, keyPath, domEvent }) => {
            navigate("/login");
        }
    }

    const loggedItem: LoginMenuItem = {
        items: [
            { 
                key: "userProfile", 
                label: `${user?.userName}`,
                icon: <Avatar icon={<UserOutlined />}/>,
                children: [
                    {
                        key: "logout",
                        label: "logout"
                    }
                ]
            }
        ],
        onClick: ({ key, keyPath, domEvent }) => { 
            console.log(key)
        }
    }

    const loginItem: LoginMenuItem = user ? loggedItem : unLoggedItem;
    // console.log(user?.userName)

    return (
        <Row gutter={16}>
            <Col className="gutter-row" flex={5}>
                <Menu theme="dark" mode="horizontal" items={leftItems} onClick={leftMenuOnClick} />
            </Col>
            <Col className="gutter-row" flex={5}>
                {
                    <Menu selectable={false} theme="dark" mode="horizontal" items={loginItem.items} onClick={loginItem.onClick} style={{ justifyContent: 'flex-end' }} />
                }
            </Col>
        </Row>
    );
};

export default HomeMenu;
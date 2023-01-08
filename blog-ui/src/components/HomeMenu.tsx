import React from 'react';
import { Row, Col } from 'antd';
import { HomeOutlined, UnorderedListOutlined, UserOutlined } from '@ant-design/icons';
import type { MenuProps } from 'antd';
import { Layout, Menu } from 'antd';
import { useNavigate } from 'react-router-dom';

type MenuItem = Required<MenuProps>['items'][number];
type MenuClickEventHandler = Required<MenuProps>['onClick'];

const HomeMenu: React.FC = () => {

    const navigate = useNavigate();

    const leftItems: MenuItem[] = [
        { key: "home", icon: <HomeOutlined />, label: "Home" },
        { key: "category", icon: <UnorderedListOutlined />, label: "Category" },
    ];

    const rightItems: MenuItem[] = [
        { key: "login", icon: <UserOutlined />, label: "Login" }
    ];

    const leftMenuOnClick: MenuClickEventHandler = ({ key, keyPath, domEvent }) => {
        navigate("/home");
    }

    const rightMenuOnClick: MenuClickEventHandler = ({ key, keyPath, domEvent }) => {
        navigate("/login");
    }

    return (
        <Row gutter={16}>
            <Col className="gutter-row" flex={5}>
                <Menu theme="dark" mode="horizontal" items={leftItems} onClick={leftMenuOnClick} />
            </Col>
            <Col className="gutter-row" flex={5}>
                <Menu selectable={false} theme="dark" mode="horizontal" items={rightItems} onClick={rightMenuOnClick} style={{ justifyContent: 'flex-end' }} />
            </Col>
        </Row>
    );
};

export default HomeMenu;
import React, { useState } from 'react';
import { AppstoreOutlined, MailOutlined, SettingOutlined } from '@ant-design/icons';
import type { MenuProps } from 'antd';
import { Menu } from 'antd';

const items: MenuProps['items'] = [
  {
    label: 'Log in',
    key: 'login',
    icon: <MailOutlined />,
  },
  {
    label: 'User Management',
    key: 'user',
    icon: <AppstoreOutlined />
  },
  {
    label: 'Category Management',
    key: 'category',
    icon: <AppstoreOutlined />
  },
];

const NavigationBar: React.FC = () => {
  const [current, setCurrent] = useState('login');

  const onClick: MenuProps['onClick'] = (e) => {
    setCurrent(e.key);
  };

  return <Menu onClick={onClick} selectedKeys={[current]} mode="horizontal" items={items} />;
};

export default NavigationBar;
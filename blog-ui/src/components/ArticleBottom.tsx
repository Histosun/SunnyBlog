import React from 'react';
import { EyeOutlined, CalendarOutlined } from '@ant-design/icons';

interface ArticleBottomProps {
    created: Date,
    viewCount: number
}

const ArticleBottom: React.FC<ArticleBottomProps> = (props:ArticleBottomProps) => {

    return (
        <div style={Style}>
            <EyeOutlined/>{props.viewCount}
            &nbsp;&nbsp;&nbsp;&nbsp;
            <CalendarOutlined/>{props.created}
        </div>
    );
}

const Style: React.CSSProperties = {
    marginTop: 17,
    color: 'grey'
};

export default ArticleBottom;
import React from 'react';
import { Link } from 'react-router-dom';
import { EyeOutlined } from '@ant-design/icons';

export interface HotArticle {
    id: number;
    title: string;
    viewCount: number;
}

const HotArticleItem: React.FC<HotArticle> = ({id, title, viewCount }: HotArticle) => {
    return (
        <p>
            <Link to={`/Article/${id}`}>
                {title}
                <span style={{flex: 'left'}}>
                    <EyeOutlined/>{viewCount}
                </span>
            </Link>
        </p>
    );
}

export default HotArticleItem;
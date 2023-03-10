import React, { ComponentProps } from 'react';
import { Navigate, NavLink, useNavigate } from 'react-router-dom';
import { Card, Badge } from 'antd';
import ArticleBottom from './ArticleBottom';

const {Meta} = Card;

export interface ArticleCardProps {
    id: number;
    title: string;
    summary: string;
    viewCount: number;
    created: Date;
    categoryName?: string;
}

const ArticleCard: React.FC<ArticleCardProps> = ({id, title, summary, viewCount,created, categoryName}: ArticleCardProps) => {
    const navigate = useNavigate();
    const navArticleDetail = (id:number) => {
        navigate(`/Article/${id}`)
    }
    return (
        <Badge.Ribbon text={categoryName} placement='start' >
            <Card title={title} onClick={() => navArticleDetail(id)} hoverable headStyle={titleStyle} style={mainStyle}>
                <div style={metaStyle}>{summary}</div>
                <ArticleBottom created={created} viewCount={viewCount}/>
            </Card>
        </Badge.Ribbon>
    );
}

const titleStyle: React.CSSProperties = { textAlign: "center" };
const mainStyle: React.CSSProperties = { marginBottom: 30 };
const metaStyle: React.CSSProperties = {
    fontSize: 17,
    color: 'black'
}

export default ArticleCard;
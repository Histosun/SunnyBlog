import React, { ComponentProps } from 'react';
import { Card, Badge } from 'antd';

const {Meta} = Card;

export interface ArticleCardProps {
    id: number;
    title: string;
    summary: string;
    viewCount: number;
    created?: Date;
    categoryName?: string;
}

const ArticleCard: React.FC<ArticleCardProps> = ({id, title, summary, created, categoryName}: ArticleCardProps) => {
    const titleStyle: React.CSSProperties = { textAlign: "center" };
    const mainStyle: React.CSSProperties = { marginBottom: 30 };

    return (
        <Badge.Ribbon text={categoryName} placement='start' >
            <Card title={title} hoverable headStyle={titleStyle} style={mainStyle}>
                <Meta description={summary} />
            </Card>
        </Badge.Ribbon>
    );
}

export default ArticleCard;
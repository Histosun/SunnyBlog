import React, { ComponentProps } from 'react';
import { Card, Badge } from 'antd';

const {Meta} = Card;

interface ArticleCardProps {
    title: string;
    tag: string;
    imgUrl?: string;
    description?: string;
}

const ArticleCard: React.FC<ArticleCardProps> = ({title, tag, imgUrl, description}: ArticleCardProps) => {
    const titleStyle: React.CSSProperties = { textAlign: "center" };
    const mainStyle: React.CSSProperties = { marginBottom: 30 };

    return (
        <Badge.Ribbon text={tag} placement='start' >
            <Card title={title} hoverable headStyle={titleStyle} style={mainStyle}>
                <Meta description={description} />
            </Card>
        </Badge.Ribbon>
    );
}

export default ArticleCard;
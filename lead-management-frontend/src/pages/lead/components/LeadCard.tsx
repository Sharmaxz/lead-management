import {Card, Avatar, Space, Typography, Button, Row, Col, Divider} from "antd";
import {UserOutlined, EnvironmentOutlined, InboxOutlined, PhoneOutlined, MailOutlined} from "@ant-design/icons";
import "./LeadCard.css";
import {Lead} from "../../../models/Lead.js";

const {Title, Text} = Typography;

const formatDate = (dateString?: string, showYear: boolean = false): string => {
    if (!dateString) return "Unknown Date";
    const date = new Date(dateString);

    return date.toLocaleString("en-US", {
        month: "long",
        day: "numeric",
        year: showYear ? "numeric" : undefined,
        hour: "numeric",
        minute: "numeric",
        hour12: true,
    }).replace("at", "@");
};

const formatPrice = (price?: number | string): string => {
    if (!price) return "$0.00";
    const numericPrice = typeof price === "string" ? parseFloat(price) : price;
    return new Intl.NumberFormat("en-US", {
        style: "currency",
        currency: "USD",
        minimumFractionDigits: 2,
    }).format(numericPrice);
};

const getLeadName = (lead: Lead): string => {
    return lead.status === "Accepted" ? lead.contactFullName || "No Name" : lead.contactFirstName || "No Name";
};

interface LeadProps {
    lead?: Lead;
    onAccept?: (id: string | number) => void;
    onDecline?: (id: string | number) => void;
}

const LeadCard = ({lead, onAccept, onDecline}: LeadProps) => {
    const isAccepted = lead.status === "Accepted";

    return (
        <Card className="lead-card">
            <Row align="middle" justify="start" gutter={12}>
                <Col>
                    <Avatar size={48} style={{backgroundColor: "#faad14"}} icon={<UserOutlined/>}/>
                </Col>
                <Col flex="auto">
                    <Title level={5} style={{margin: 0}}>{getLeadName(lead)}</Title>
                    <Text type="secondary">{formatDate(lead.dateCreated, isAccepted)}</Text>
                </Col>
            </Row>

            <Divider className="small-divider"/>

            <Row gutter={[12, 12]} justify="start" align="middle">
                <Col>
                    <Space>
                        <EnvironmentOutlined/>
                        <Text>{lead.suburb || "N/A"}</Text>
                    </Space>
                </Col>
                <Col>
                    <Space>
                        <InboxOutlined/>
                        <Text>{lead.category || "N/A"}</Text>
                    </Space>
                </Col>
                <Col>
                    <Text>Job ID: {lead.id || "N/A"}</Text>
                </Col>
                {isAccepted && (
                    <Col>
                        <Text>{formatPrice(lead.price)} Lead Invitation</Text>
                    </Col>
                )}
            </Row>

            <Divider className="small-divider"/>

            {!isAccepted && (
                <Text className="lead-description">{lead.description || "No description available."}</Text>
            )}

            {isAccepted && (
                <>
                    <Row gutter={[16, 8]}>
                        <Col>
                            <Space>
                                <PhoneOutlined />
                                <Text strong style={{color: "#fa8c16"}}>{lead.contactPhoneNumber || "N/A"}</Text>
                            </Space>
                        </Col>
                        <Col>
                            <Space>
                                <MailOutlined />
                                <Text style={{color: "#fa8c16"}}>{lead.contactEmail || "N/A"}</Text>
                            </Space>
                        </Col>
                    </Row>

                    <Text className="lead-description">{lead.description || "No description available."}</Text>
                </>
            )}


            {!isAccepted && (
                <>
                    <Divider/>

                    <Row align="middle">
                        <Col>
                            <Space>
                                <Button type="primary" className="accept-btn"
                                        onClick={() => onAccept?.(lead.id)}>Accept</Button>
                                <Button className="decline-btn" onClick={() => onDecline?.(lead.id)}>Decline</Button>
                            </Space>
                        </Col>
                        <Col>
                            <Text strong className="lead-price">{formatPrice(lead.price)}</Text>
                            <Text style={{fontSize: "14px"}}>Lead Invitation</Text>
                        </Col>
                    </Row>
                </>
            )}
        </Card>
    );
};


export default LeadCard;

import { useEffect, useState } from "react";
import { Tabs, List, Typography } from "antd";
import axios from "axios";
import "./Leads.css";
import LeadCard from "./components/LeadCard";

const { Text } = Typography;
const { TabPane } = Tabs;

const Leads = () => {
    const [leads, setLeads] = useState([]);
    const [tab, setTab] = useState("invited");

    useEffect(() => {
        fetchLeads();
    }, []);

    const fetchLeads = () => {
        axios.get("https://localhost:7168/api/leads")
            .then(response => setLeads(response.data))
            .catch(error => console.error("Erro ao buscar leads:", error));
    };

    const handleAccept = (id) => {
        axios.put(`https://localhost:7168/api/leads/${id}/accept`)
            .then(() => {
                fetchLeads();
            })
            .catch(error => console.error("Erro ao aprovar lead:", error));
    };


    const handleDecline = (id) => {
        axios.put(`https://localhost:7168/api/leads/${id}/decline`)
            .then(() => {
                fetchLeads();
            })
            .catch(error => console.error("Erro ao reprovar lead:", error));
    };

    return (
        <div style={{ backgroundColor: "#f5f5f5", minHeight: "100vh", padding: "20px" }}>
            <Tabs activeKey={tab} onChange={setTab} centered className="custom-tabs">
                <TabPane tab="Invited" key="invited">
                    {leads.filter(lead => lead.status === "Invited").length === 0 ? (
                        <Text type="secondary">Nenhum lead encontrado.</Text>
                    ) : (
                        <List
                            dataSource={leads.filter(lead => lead.status === "Invited")}
                            renderItem={(lead) => (
                                <LeadCard lead={lead} onAccept={handleAccept} onDecline={handleDecline} />
                            )}
                        />
                    )}
                </TabPane>

                <TabPane tab="Accepted" key="accepted">
                    {leads.filter(lead => lead.status === "Accepted").length === 0 ? (
                        <Text type="secondary">Nenhum lead aceito.</Text>
                    ) : (
                        <List
                            dataSource={leads.filter(lead => lead.status === "Accepted")}
                            renderItem={(lead) => (
                                <LeadCard lead={lead} />
                            )}
                        />
                    )}
                </TabPane>
            </Tabs>
        </div>
    );
};

export default Leads;

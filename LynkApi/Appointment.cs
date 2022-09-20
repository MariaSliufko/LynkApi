﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynkApi
{
    public class Appointment
    {
        // LynkApi myDeserializedClass = JsonConvert.DeserializeObject<LynkApi>(myJsonResponse);
        
            [JsonProperty("appointment_id")]
            public string? AppointmentId { get; set; }

            [JsonProperty("location_id")]
            public string? LocationId { get; set; }

            [JsonProperty("vehicle_id")]
            public string? VehicleId { get; set; }

            [JsonProperty("vehicle_registration_plate")]
            public string? VehicleRegistrationPlate { get; set; }

            [JsonProperty("expected_vehicle_milage")]
            public string? ExpectedVehicleMilage { get; set; }

            [JsonProperty("assignment_types")]
            public List<string>? AssignmentTypes { get; set; }

            [JsonProperty("vehicle_color_id")]
            public string? VehicleColorId { get; set; }

            [JsonProperty("scheduled_vehicle_arrival_time")]
            public DateTime? ScheduledVehicleArrivalTime { get; set; }

            [JsonProperty("scheduled_vehicle_pickup_time")]
            public DateTime? ScheduledVehiclePickupTime { get; set; }

            [JsonProperty("status")]
            public string? Status { get; set; }

            [JsonProperty("scheduled_work_start_time")]
            public DateTime? ScheduledWorkStartTime { get; set; }

            [JsonProperty("scheduled_work_end_time")]
            public DateTime? ScheduledWorkEndTime { get; set; }


            [JsonConstructor]
            public Appointment(
            [JsonProperty("appointment_id")] string appointmentId,
            [JsonProperty("location_id")] string locationId,
            [JsonProperty("vehicle_id")] string vehicleId,
            [JsonProperty("vehicle_registration_plate")] string vehicleRegistrationPlate,
            [JsonProperty("expected_vehicle_milage")] string expectedVehicleMilage,
            [JsonProperty("assignment_types")] List<string> assignmentTypes,
            [JsonProperty("vehicle_color_id")] string vehicleColorId,
            [JsonProperty("scheduled_vehicle_arrival_time")] DateTime scheduledVehicleArrivalTime,
            [JsonProperty("scheduled_vehicle_pickup_time")] DateTime scheduledVehiclePickupTime,
            [JsonProperty("status")] string status,
            [JsonProperty("scheduled_work_start_time")] DateTime? scheduledWorkStartTime,
            [JsonProperty("scheduled_work_end_time")] DateTime? scheduledWorkEndTime
        )
            {
                this.AppointmentId = appointmentId;
                this.LocationId = locationId;
                this.VehicleId = vehicleId;
                this.VehicleRegistrationPlate = vehicleRegistrationPlate;
                this.ExpectedVehicleMilage = expectedVehicleMilage;
                this.AssignmentTypes = assignmentTypes;
                this.VehicleColorId = vehicleColorId;
                this.ScheduledVehicleArrivalTime = scheduledVehicleArrivalTime;
                this.ScheduledVehiclePickupTime = scheduledVehiclePickupTime;
                this.Status = status;
                this.ScheduledWorkStartTime = scheduledWorkStartTime;
                this.ScheduledWorkEndTime = scheduledWorkEndTime;
            }

        public class Root
        {
            [JsonConstructor]
            public Root(
                [JsonProperty("appointments")] List<Appointment> appointments
            )
            {
                this.Appointments = appointments;
            }

            [JsonProperty("appointments")]
            public IReadOnlyList<Appointment> Appointments { get; }
        }


    }
}
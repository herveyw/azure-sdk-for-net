// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Management.Sql
{
    /// <summary>
    /// Represents all the operations for operating on Azure SQL Server Active
    /// Directory Administrators.  Contains operations to: Create, Retrieve,
    /// Update, and Delete Azure SQL Server Active Directory Administrators.
    /// </summary>
    public partial interface IServerAdministratorOperations
    {
        /// <summary>
        /// Begins creating a new Azure SQL Server Active Directory
        /// Administrator or updating an existing Azure SQL Server Active
        /// Directory Administrator. To determine the status of the operation
        /// call GetServerAdministratorOperationStatus.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Resource Group to which the server belongs.
        /// </param>
        /// <param name='serverName'>
        /// The name of the Azure SQL Server to which the Azure SQL Server
        /// Active Directory administrator belongs
        /// </param>
        /// <param name='administratorName'>
        /// The name of the Azure SQL Server Active Directory Administrator.
        /// </param>
        /// <param name='parameters'>
        /// The required parameters for createing or updating an Active
        /// Directory Administrator.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Response for long running Azure SQL Server Active Directory
        /// Administrator operations.
        /// </returns>
        Task<ServerAdministratorCreateOrUpdateResponse> BeginCreateOrUpdateAsync(string resourceGroupName, string serverName, string administratorName, ServerAdministratorCreateOrUpdateParameters parameters, CancellationToken cancellationToken);
        
        /// <summary>
        /// Begins deleting an existing Azure SQL Server Active Directory
        /// Administrator.To determine the status of the operation call
        /// GetServerAdministratorDeleteOperationStatus.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Resource Group to which the server belongs.
        /// </param>
        /// <param name='serverName'>
        /// The name of the Azure SQL Server to which the Azure SQL Server
        /// Active Directory administrator belongs
        /// </param>
        /// <param name='administratorName'>
        /// The name of the Azure SQL Server Active Directory Administrator.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Response for long running Azure SQL Server Active Directory
        /// administrator delete operations.
        /// </returns>
        Task<ServerAdministratorDeleteResponse> BeginDeleteAsync(string resourceGroupName, string serverName, string administratorName, CancellationToken cancellationToken);
        
        /// <summary>
        /// Creates a new Azure SQL Server Active Directory Administrator or
        /// updates an existing Azure SQL Server Active Directory
        /// Administrator.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Resource Group to which the server belongs.
        /// </param>
        /// <param name='serverName'>
        /// The name of the Azure SQL Server on which the Azure SQL Server
        /// Active Directory Administrator is hosted.
        /// </param>
        /// <param name='administratorName'>
        /// The name of the Azure SQL Server Active Directory Administrator to
        /// be operated on (Updated or created).
        /// </param>
        /// <param name='parameters'>
        /// The required parameters for creating or updating a Server
        /// Administrator.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Response for long running Azure SQL Server Active Directory
        /// Administrator operations.
        /// </returns>
        Task<ServerAdministratorCreateOrUpdateResponse> CreateOrUpdateAsync(string resourceGroupName, string serverName, string administratorName, ServerAdministratorCreateOrUpdateParameters parameters, CancellationToken cancellationToken);
        
        /// <summary>
        /// Deletes an existing Azure SQL Server Active Directory Administrator.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Resource Group to which the server belongs.
        /// </param>
        /// <param name='serverName'>
        /// The name of the Azure SQL Server to which the Azure SQL Server
        /// Active Directory administrator belongs
        /// </param>
        /// <param name='administratorName'>
        /// The name of the Azure SQL Server Active Directory Administrator to
        /// be operated on (Updated or created).
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Response for long running Azure SQL Server Active Directory
        /// administrator delete operations.
        /// </returns>
        Task<ServerAdministratorDeleteResponse> DeleteAsync(string resourceGroupName, string serverName, string administratorName, CancellationToken cancellationToken);
        
        /// <summary>
        /// Returns an Azure SQL Server Administrator.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Resource Group to which the server belongs.
        /// </param>
        /// <param name='serverName'>
        /// The name of the Azure SQL Server to which the Azure SQL Server
        /// Active Directory administrator belongs.
        /// </param>
        /// <param name='administratorName'>
        /// The name of the Azure SQL Server Active Directory Administrator.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Represents the response to a Get Azure SQL Server Active Directory
        /// Administrators request.
        /// </returns>
        Task<ServerAdministratorGetResponse> GetAsync(string resourceGroupName, string serverName, string administratorName, CancellationToken cancellationToken);
        
        /// <summary>
        /// Gets the status of an Azure SQL Server Active Directory
        /// Administrator delete operation.
        /// </summary>
        /// <param name='operationStatusLink'>
        /// Location value returned by the Begin operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Response for long running Azure SQL Server Active Directory
        /// administrator delete operations.
        /// </returns>
        Task<ServerAdministratorDeleteResponse> GetServerAdministratorDeleteOperationStatusAsync(string operationStatusLink, CancellationToken cancellationToken);
        
        /// <summary>
        /// Gets the status of an Azure SQL Server Active Directory
        /// Administrator create or update operation.
        /// </summary>
        /// <param name='operationStatusLink'>
        /// Location value returned by the Begin operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Response for long running Azure SQL Server Active Directory
        /// Administrator operations.
        /// </returns>
        Task<ServerAdministratorCreateOrUpdateResponse> GetServerAdministratorOperationStatusAsync(string operationStatusLink, CancellationToken cancellationToken);
        
        /// <summary>
        /// Returns a list of Azure SQL Server Administrators.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Resource Group to which the server belongs.
        /// </param>
        /// <param name='serverName'>
        /// The name of the Azure SQL Server to which the Azure SQL Server
        /// Active Directory administrators belongs.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Represents the response to a List Azure SQL Active Directory
        /// Administrators request.
        /// </returns>
        Task<ServerAdministratorListResponse> ListAsync(string resourceGroupName, string serverName, CancellationToken cancellationToken);
    }
}